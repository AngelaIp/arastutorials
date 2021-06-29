var dlvAssignedTo = document.thisItem.getProperty('dlv_assignedto');
if (dlvAssignedTo) 
{
    if (!top.aras.confirm('Do you want to send mail to DLV Assigned to User ?')) 
    {
	return;
    }
    var callServerMethod = aras.IomInnovator.newItem('Method', 'SendEmailFromOnChangeField_Server');
    callServerMethod.setProperty('dlv_assignedto', dlvAssignedTo);
    callServerMethod.setProperty('item_number', document.thisItem.getProperty('item_number'));
    var result = callServerMethod.apply();
    if (result.isError()) 
    {
        aras.AlertError(result.getErrorString());
    }
    else 
    {
        aras.AlertSuccess('Email sent successfully.');
    }
}