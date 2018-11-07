@CRS_Id:ACS-2.0-CRS-009
@FS_Document_No:867065-90077
@FS_Document_Name:IntelliSpace_Console_Critical_Care_B.01_Checklist_Feature_Specification
Feature: Launch Checklist
       In order to launch checklist view
       As a Clinician
       I want to be allowed to click on checklist icon

Background: User is Logged In
       Given I navigate to the login page
       When I submit username and password
       Then I should be logged in 

@FS_Id:ISC-B.01-CHK-1
@Spec_Tag:187315
@Spec_TagName:SRS:<ISC-B.01-CHK-1>ChecklistFS
@Test_Id:189487 @Test_Name:Checklist_indicator_and_launching_of_the_Feature
@Priority:High_Want
Scenario: Click the checklist icon in SPV
       Given I have draft checklist for Patient-A 
       When I click on the checklist icon
       Then the checklist view should be launched

@FS_Id:ISC-B.01-CHK-2
@Spec_Tag:187316
@Spec_TagName:SRS:<ISC-B.01-CHK-2>ChecklistFS
@Test_Id:189487 @Test_Name:Checklist:Checklist_indicator_and_launching_of_the_Feature
@Test_Id:189638  @Test_Name:Workflow:Transfer_to_Non-Console
@Test_Id:189639 @Test_Name:Workflow:Transfer_within_Console
@Test_Id:189642 @Test_Name:Workflow:Discharge/Readmit
@Priority:Must
Scenario Outline:Click the Checklist icon in MPV
       Given I have final checklist for <patient>
       When I click on the checklist icon of <patient>
       Then the checklist view of <patient> should be launched

       Examples: 
       | patient   |
       | Patient-B |
       | Patient-C |

@FS_Id:ISC-B.01-CHK-3
@Spec_Tag:187317
@Spec_TagName:SRS:<ISC-B.01-CHK-3>ChecklistFS
@Test_Id:189443 @Test_Name:Save_Checklist
@Priority:Want
Scenario: Clicking the “Save” button saves the checklist for the selected format and return to the originating application launch context, i.e., MPV or SPV.
       Given I have navigated from MPV on clicking draft checklist icon
       And given the following inputs
       | fields   | values |
       | ID       |        |
       | state    | Draft  |
       | question | XYZ    |
       When I click on the "Save" button
       Then Checklist should be saved as draft
       And user should be navigated to MPV 
