//
//  DrugNote.m
//  PHR
//
//  Created by BillyMobile on 5/23/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "DrugNote.h"

@implementation DrugNote

+ (DrugNote *)initializeMedicinFrom:(NSDictionary *)dict{
    
    DrugNote *objNote = [DrugNote new];
    objNote.drug_id    = [Validator getSafeString:dict[KEY_Drug_ID]];
    objNote.drug_name  = [Validator getSafeString:dict[KEY_Drug_Name]];
    objNote.dose    = [Validator getSafeString:dict[KEY_Drug_Dose]];
    objNote.method = [Validator getSafeString:dict[KEY_Drug_Method]];
    objNote.note = [Validator getSafeString:dict[KEY_Drug_Note]];
    if([Validator getSafeString:dict[KEY_Drug_Quantity]] != nil && (id)[Validator getSafeString:dict[KEY_Drug_Quantity]] != [NSNull null]){
        objNote.quantity = [[Validator getSafeString:dict[KEY_Drug_Quantity]] intValue];
    }else{
        objNote.quantity = 0;
    }
    
    objNote.time = [Validator getSafeString:dict[KEY_Drug_Time]];
    objNote.unit = [Validator getSafeString:dict[KEY_Drug_Unit]];
    objNote.frequency = [[Validator getSafeString:dict[KEY_Drug_Frequency]] intValue];

    return objNote;
}

+ (DrugNote*)initFromOrderModel:(OrderModel*)orderModel {
  
  DrugNote *objNote = [DrugNote new];
  objNote.drug_id    = @"";
  objNote.drug_name  = orderModel.HangmogName;
  objNote.method = orderModel.GubunBass;
  objNote.dose    = orderModel.GubunBass;
  if (orderModel.Dv) {
    objNote.frequency = [orderModel.Dv intValue];
  } else {
    objNote.frequency = 0;
  }
  if (orderModel.Nalsu) {
    objNote.quantity = [orderModel.Nalsu intValue];
  } else {
    objNote.quantity = 0;
  }
  objNote.unit = orderModel.OrdDanuiName;
  objNote.time = orderModel.NaewonDate;
  objNote.dosage = orderModel.BogyongName;
  
  return objNote;
}


@end
