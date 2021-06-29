ARAS Community Forum Question Link : https://community.aras.com/f/development/34948/send-email-to-task-assignee-by-field-event

******************************************************************************************************************************
Solution:

Follow below steps
1. Create new JavaScript method with name SendEmailFromOnChangeField_JS
2. Copy the method Code from SendEmailFromOnChangeField_JS file in GIT Folder
3. Create new C# method with name SendEmailFromOnChangeField_Server
4. Copy the method Code from SendEmailFromOnChangeField_Server file in GIT Folder
5. Open the form where this dlv_assignedto property exist
6. Add Form field event (Method Name : SendEmailFromOnChangeField_JS and event : On Change) on dlv_assignedto property 
7. Save and Unlock Form

******************************************************************************************************************************