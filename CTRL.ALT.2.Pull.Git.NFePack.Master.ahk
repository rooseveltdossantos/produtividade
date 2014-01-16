ProgramFilesX86 := A_ProgramFiles . (A_PtrSize=8 ? " (x86)" : "")
^!2::
IfWinExist nfepack (master2) - Git Extensions
{
    WinActivate	
}
else
{
	Run "%ProgramFilesX86%\GitExtensions\GitExtensions.exe", C:\dev\inventti\nfepack
    WinWait Git Extensions
    WinActivate
}
Send {CtrlDown}{Down}{CtrlUp}
Send {AltDown}R{AltUp}
Send {AltDown}P{AltUp}


