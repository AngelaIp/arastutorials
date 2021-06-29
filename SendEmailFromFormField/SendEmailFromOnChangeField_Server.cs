Innovator inn = this.getInnovator();
string str_body = "";

// Get assignee
string assignee = this.getProperty("dlv_assignedto","");

//Get Url
string str_actionID = this.getProperty("item_number","");
string str_actionReq = "DLV_ActionReq";
string link = string.Format(@"<html><p><a href=""{2}/Default.aspx?StartItem={0}:{1}"">Click here to open the ticket</a></p></html>",str_actionReq, str_actionID, CCO.Request.Url.ToString().Substring(0,CCO.Request.Url.ToString().IndexOf("/Server/")));

// Get Mail
Item email = inn.newItem("Email Message", "get");
email.setID("35DF32E58F02491B99B0450DA70AF85E"); //DLV_ActionReq_Assignment
email = email.apply();

email.setProperty("subject", string.Format("The following Action Request {0} has been assigned to you",str_actionID));
str_body = string.Format(@"<html><B>The following Action Request {0} has been assigned to you. <br>{1} <br>Best regards,<br>Engineering Capability Office",str_actionID, link);

email.setProperty("body_html", str_body);

// Get Identity for assignee
if ( assignee != "" )
{
Item userItem = inn.newItem("User", "get");
userItem.setAttribute("select", "id");
Item aliasItem = inn.newItem("Alias", "get");
aliasItem.setAttribute("select", "related_id");
Item identity = inn.newItem("Identity", "get");
aliasItem.setPropertyItem("related_id", identity);
userItem.addRelationship(aliasItem);
userItem.setID(assignee);
userItem = userItem.apply();
if (userItem.isError())
{
return userItem;
}
aliasItem = userItem.getRelationships("Alias");
Item iden = aliasItem.getItemByIndex(0).getRelatedItem();
if (iden.getItemCount() == 1)
{
    Boolean result = this.email(email, iden);
}
}
return this;