//
//  MedicineNote.m
//  PHR
//
//  Created by Luong Le Hoang on 10/15/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "MedicineNote.h"

@implementation MedicineNote


+ (MedicineNote *)initializeMedicinFrom:(NSDictionary *)dict {
    MedicineNote *objNote = [MedicineNote new];
    NSDate  *dateTime   = [UIUtils dateFromServerTimeString:[dict objectForKey:KEY_MedicineNote_Time]];
    
    objNote.medicine_note_id    = [[dict objectForKey:KEY_MedicineNote_ID] intValue];
    objNote.name                = [dict objectForKey:KEY_MedicineNote_Name];
    objNote.method              = [dict objectForKey:KEY_MedicineNote_Method];
    objNote.dose                = [dict objectForKey:KEY_MedicineNote_Dose];
    objNote.note                = [dict objectForKey:KEY_Note];
    objNote.prescription_url    = [dict objectForKey:KEY_MedicineNote_Pre_URL];
    objNote.quantity            = [[dict objectForKey:KEY_MedicineNote_Quantity] intValue];
    objNote.date                = [UIUtils formatDateOppositeStyle:dateTime];
    objNote.unit                = [dict objectForKey:KEY_MedicineNote_Unit];
    objNote.time_take_medicine  = [UIUtils formatTimeStyle:dateTime];
    
    return objNote;
}


+ (NSString*)methodStringFromType:(PHRMedicineMethod)method {
    NSArray *array = [self arrayMethods];
    return method < array.count && method >= 0 ? array[method] : nil;
}

+ (NSArray*)arrayMethods {
    return @[kLocalizedString(kMedicineMethodDrink),
             kLocalizedString(kMedicineMethodInject),
             kLocalizedString(kMedicineMethodSuppository),
             kLocalizedString(kMedicineMethodInfusion)];
}

+ (NSString*)unitStringFromType:(PHRMedicineUnit)unit {
    NSArray *array = [self arrayUnits];
    return unit < array.count && unit >= 0 ? array[unit] : nil;
}

+ (NSArray*)arrayUnits {
    return @[kLocalizedString(kMedicineUnitCapsule),
             kLocalizedString(kMedicineUnitPill),
             kLocalizedString(kMedicineUnitAmpoule)];
}

+ (MedicineNote *)initializeMedicinFromModel:(BabyMedicineModel *)model andDate:(NSString *)dateTime {
    MedicineNote *objNote = [MedicineNote new];
    objNote.date                = dateTime;
    objNote.name                = model.name;
    objNote.method              = model.method;
    objNote.dose                = model.dose;
    objNote.note                = model.note;
    objNote.prescription_url    = model.prescription_url;
    objNote.quantity            = [model.quantity intValue];
    objNote.unit                = model.unit;
    objNote.time_take_medicine  = model.time_take_medicine;
    objNote.medicine_note_id    = [model.id intValue];
    return objNote;
}

+ (MedicineNote *)initializeMedicinFromModel:(BabyMedicineModel *)model {
    MedicineNote *objNote = [MedicineNote new];
    NSDate *dateTime            = [UIUtils dateFromServerTimeString:model.time_take_medicine];
    objNote.date                = [UIUtils formatDateOppositeStyle:dateTime];
    objNote.name                = model.name;
    objNote.method              = model.method;
    objNote.dose                = model.dose;
    objNote.note                = model.note;
    objNote.prescription_url    = model.prescription_url;
    objNote.quantity            = [model.quantity intValue];
    objNote.unit                = model.unit;
    objNote.time_take_medicine  = [UIUtils formatTimeStyle:dateTime];
    objNote.medicine_note_id    = [model.id intValue];
    return objNote;
}

@end
