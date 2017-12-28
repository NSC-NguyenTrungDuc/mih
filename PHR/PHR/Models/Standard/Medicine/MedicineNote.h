//
//  MedicineNote.h
//  PHR
//
//  Created by Luong Le Hoang on 10/15/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "BabyMedicineModel.h"

@interface MedicineNote : NSObject{
    
}

@property (nonatomic) int medicine_note_id;
@property (nonatomic) int quantity;

@property (nonatomic, strong) NSString *date;
@property (nonatomic, strong) NSString *time_take_medicine;
@property (nonatomic, strong) NSString *name;
@property (nonatomic, strong) NSString *method;
@property (nonatomic, strong) NSString *unit;
@property (nonatomic, strong) NSString *dose;
@property (nonatomic, strong) NSString *prescription_url;
@property (nonatomic, strong) NSString *note;

+ (NSString*)methodStringFromType:(PHRMedicineMethod)method;
+ (NSArray*)arrayMethods;
+ (NSString*)unitStringFromType:(PHRMedicineUnit)unit;
+ (NSArray*)arrayUnits;
+ (MedicineNote *)initializeMedicinFrom:(NSDictionary *)dict;
+ (MedicineNote *)initializeMedicinFromModel:(BabyMedicineModel *)model andDate:(NSString *)dateTime;
+ (MedicineNote *)initializeMedicinFromModel:(BabyMedicineModel *)model;
@end
