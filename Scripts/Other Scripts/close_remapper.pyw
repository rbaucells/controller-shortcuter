import psutil

def ClosePythonScript(scriptName : str):
    for proc in psutil.process_iter(['cmdline']):
        args = proc.info.get('cmdline', list)
        if isinstance(args, list):
            for arg in args:
                if isinstance(arg, str) and scriptName in arg:
                    proc.kill()
                    break
        elif isinstance(args, str):
            if scriptName in args:
                proc.kill()
                break

ClosePythonScript("controller_remapper.pyw")