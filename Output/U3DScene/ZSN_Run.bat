@ECHO OFF

::	���û�������
::	Set DataLocation=(����GameEditor·��)
::	
::	����
::	(prefix):[param]=[value];[param]=[value];[param]=[value];
::	
::	MapID		��ͼ��ģ��ID
::	UserID		��ɫ��ģ��ID
::	FolderPath	data��Ŀ¼
::	ResPath		AssetBundle��u3d����Դ·��

::Variables definition
SET DataLocation=E:\Heros\Client\GameEditors\GameEditor

start %cd%/U3DSceneRun.exe -CustomArgs:MapID=100101;UserID=11001;FolderPath=%DataLocation%/;ResPath=file://%DataLocation%