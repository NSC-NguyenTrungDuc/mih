//
//  PresciptionObject.m
//  PHR
//
//  Created by BillyMobile on 5/21/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "PresciptionObject.h"

@implementation PresciptionObject

+ (PresciptionObject *)initializeMedicinFrom:(NSDictionary *)dict {
    
    PresciptionObject *objNote = [PresciptionObject new];
    objNote.prescription_id    = [dict objectForKey:KEY_Prescription_ID] ;
    objNote.prescription_name  = [dict objectForKey:KEY_Prescription_Name];
    objNote.datetime_record    = [dict objectForKey:KEY_Prescription_Time];
    objNote.prescription_url = [dict objectForKey:KEY_Prescription_URL];
    return objNote;
}

@end
