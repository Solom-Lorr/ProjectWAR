UPDATE `war_world`.`ability_line_to_buff_type` SET `ID` = '0' WHERE `Line ID` = '1001'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `ID` = '0' WHERE `Line ID` = '1002'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `ID` = '0' WHERE `Line ID` = '1003'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `ID` = '0' WHERE `Line ID` = '1004'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `ID` = '0' WHERE `Line ID` = '1005'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `ID` = '0' WHERE `Line ID` = '1006'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `ID` = '0' WHERE `Line ID` = '1007'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `ID` = '0' WHERE `Line ID` = '1008'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `ClientSideEnumerationValue` = '0' , `BuffFrameRed` = '0' WHERE `Line ID` = '1001'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `BuffFrameRed` = '0' WHERE `Line ID` = '1002'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `BuffFrameRed` = '0' WHERE `Line ID` = '1003'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `BuffFrameRed` = '0' WHERE `Line ID` = '1004'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `BuffFrameRed` = '0' WHERE `Line ID` = '1005'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `BuffFrameRed` = '0' WHERE `Line ID` = '1006'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `BuffFrameRed` = '0' WHERE `Line ID` = '1007'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `ClientSideEnumerationValue` = '0' , `BuffFrameRed` = '0' WHERE `Line ID` = '1008'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `ClientSideEnumerationValue` = '0' WHERE `Line ID` = '1007'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `ClientSideEnumerationValue` = '0' WHERE `Line ID` = '1006'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `ClientSideEnumerationValue` = '0' WHERE `Line ID` = '1005'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `ClientSideEnumerationValue` = '0' WHERE `Line ID` = '1004'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `ClientSideEnumerationValue` = '0' WHERE `Line ID` = '1003'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `ClientSideEnumerationValue` = '0' WHERE `Line ID` = '1002'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `BuffFrameGreen` = '0' WHERE `Line ID` = '1001'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `BuffFrameGreen` = '0' WHERE `Line ID` = '1002'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `BuffFrameGreen` = '0' WHERE `Line ID` = '1003'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `BuffFrameGreen` = '0' WHERE `Line ID` = '1004'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `BuffFrameGreen` = '0' WHERE `Line ID` = '1005'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `BuffFrameGreen` = '0' WHERE `Line ID` = '1006'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `BuffFrameGreen` = '0' WHERE `Line ID` = '1007'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `BuffFrameGreen` = '0' , `BuffFrameBlue` = '0' WHERE `Line ID` = '1008'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `BuffFrameBlue` = '0' WHERE `Line ID` = '1007'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `BuffFrameBlue` = '0' WHERE `Line ID` = '1006'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `BuffFrameBlue` = '0' WHERE `Line ID` = '1005'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `BuffFrameBlue` = '0' WHERE `Line ID` = '1004'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `BuffFrameBlue` = '0' WHERE `Line ID` = '1003'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `BuffFrameBlue` = '0' WHERE `Line ID` = '1002'; 
UPDATE `war_world`.`ability_line_to_buff_type` SET `BuffFrameBlue` = '0' WHERE `Line ID` = '1001'; 
ALTER TABLE `war_world`.`ability_line_to_buff_type` CHANGE `Type Name` `Type Name` TEXT CHARSET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL, CHANGE `Client-side Enumeration Value` `Client-side Enumeration Value` INT(11) NOT NULL, CHANGE `Buff Frame Red` `Buff Frame Red` INT(11) NOT NULL, CHANGE `Buff Frame Green` `Buff Frame Green` INT(11) NOT NULL, CHANGE `Buff Frame Blue` `Buff Frame Blue` INT(11) NOT NULL, CHANGE `ID` `ID` INT(11) NOT NULL, CHANGE `TypeName` `TypeName` TEXT CHARSET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL, CHANGE `ClientSideEnumerationValue` `ClientSideEnumerationValue` INT(11) NOT NULL, CHANGE `BuffFrameRed` `BuffFrameRed` INT(11) NOT NULL, CHANGE `BuffFrameGreen` `BuffFrameGreen` INT(11) NOT NULL, CHANGE `BuffFrameBlue` `BuffFrameBlue` INT(11) NOT NULL; 
