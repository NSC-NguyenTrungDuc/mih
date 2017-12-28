//
//  BabyMedicineModel.h
//  PHR
//
//  Created by DEV-MinhNN on 11/16/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <JSONModel/JSONModel.h>

@protocol BabyMedicineModel
@end

@interface BabyMedicineModel : JSONModel

@property (nonatomic, strong) NSString<Optional> *id;
@property (nonatomic, strong) NSString<Optional> *alert;
@property (nonatomic, strong) NSString<Optional> *dose;
@property (nonatomic, strong) NSString<Optional> *method;
@property (nonatomic, strong) NSString<Optional> *name;
@property (nonatomic, strong) NSString<Optional> *note;
@property (nonatomic, strong) NSString<Optional> *prescription_url;
@property (nonatomic, strong) NSString<Optional> *profile_id;
@property (nonatomic, strong) NSString<Optional> *quantity;
@property (nonatomic, strong) NSString<Optional> *time_take_medicine;
@property (nonatomic, strong) NSString<Optional> *unit;

@end
