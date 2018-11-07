@CRS_Id:ACS-2.0-CRS-009
@PBI_Id:334                                                       
Feature: Save Checklist
    As an IT Engineer
    I want to view the logs
    So I can export the logs to csv format


@FS_Id:ACS-2.0-Logging-Export-1
@Test_Case:Exporting_To_Default_Location_CSV_Format
@MTM_Id:189486
Scenario: Exporting the log file into csv file from default location
    Given A default destination folder is set
    When I click the save button
    Then a file with YYYYMMDD.n.csv is created in that folder


@FS_Id:ACS-2.0-Logging-Export-2
@Test_Case:Exporting_To_Custom_Location_CSV_Format @MTM_Id:189487       
Scenario: Exporting the log file into csv file from custom location
    Given A default destination folder is set 
    And I choose the destination folder to save
    When I click the save button
    Then a file with YYYYMMDD.n.csv is created in that folder

@FS_Id:ACS-2.0-Logging-Export-3
@Test_Case:Cancel_Exporting_To_CSV_From_Default_Location @MTM_Id:189488
Scenario: Cancelling export operation from default location
    Given A default destination folder is set
    When I click the cancel button
    Then a file is not created

@FS_Id:ACP_A.0_Logging_Export_4
@Test_Case:Cancel_Exporting_To_CSV_From_Custom_Location @MTM_Id:189489
Scenario: Cancelling export operation from custom location
    Given A default destination folder is set
    And I choose the destination folder to save
    When I click the cancel button
    Then a file is not created

