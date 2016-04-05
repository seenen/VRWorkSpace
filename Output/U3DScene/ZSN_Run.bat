@ECHO OFF

::	设置环境变量
::	Set DataLocation=(本地GameEditor路径)
::	
::	参数
::	(prefix):[param]=[value];[param]=[value];[param]=[value];
::	
::	MapID		地图的模板ID
::	UserID		角色的模板ID
::	FolderPath	data的目录
::	ResPath		AssetBundle等u3d的资源路径

::Variables definition
SET DataLocation=E:\Heros\Client\GameEditors\GameEditor

start %cd%/U3DSceneRun.exe -CustomArgs:MapID=100101;UserID=11001;FolderPath=%DataLocation%/;ResPath=file://%DataLocation%