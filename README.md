Scheduler
=========

Windows service Scheduler - Runs ITask type in given dll path fetched from DB Table - Email notifications extended - 


STEP 1: Download Folder ApplicationToInstall

STEP 2: Create a C# class Extending TaskBase class in Scheduler.Base.dll


STEP 3: Override Run Method and do any operation that is to be scheduled

STEP 4: Build your project and get the path of .dll of your class

STEP 5: Open database inside the downloaded folder => \Data\ScheduleConfigDB.sdf
username sa password admin

STEP 6: Add row in table ScheduleConfigurations
with values from columns
AssemblyName	= "Your dll path" Eg: D:\EmailNotification.dll
TypeName	= "Your class that extends TaskBase" Eg:EmailNotification.EmailNotificationTask
Interval	= periodicity in milliseconds Eg: 60000 [1min]
DueTime		= Elapse time in milliseconds
Paused		= 0 or 1
CanPause	= 0 or 1
