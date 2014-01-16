^!1::
IfWinExist Visual Studio Command Prompt (2010)
{
    WinActivate	
}
else
{
    Run "C:\Users\Roosevelt\AppData\Roaming\Microsoft\Internet Explorer\Quick Launch\User Pinned\StartMenu\Visual Studio Command Prompt (2010).lnk"
    WinWait Visual Studio Command Prompt (2010)
    WinActivate	
}
Send C:{Enter}
Send cd \Dev\inventti\NFePack{Enter}
Send cls{Enter}
Send msbuild NFePack.msbuild /t:Compile{Enter}