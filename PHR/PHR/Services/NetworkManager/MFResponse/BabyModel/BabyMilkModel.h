//
//  BabyMilkModel.h
//  PHR
//
//  Created by DEV-MinhNN on 11/16/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <JSONModel/JSONModel.h>

@protocol BabyMilkModel
@end

@interface BabyMilkModel : JSONModel

@property (nonatomic, strong) NSString *id;
@property (nonatomic, strong) NSString *profile_id;
@property (nonatomic, strong) NSString *time_drink_milk;
@property (nonatomic, strong) NSString *drink_method;
@property (nonatomic, strong) NSString<Optional> *alert;
@property (nonatomic, strong) NSString<Optional> *bottle_milk_volume;
@property (nonatomic, strong) NSString<Optional> *breast_time;
@property (nonatomic, strong) NSString<Optional> *calories;
@property (nonatomic, strong) NSString<Optional> *milk_type;
@property (nonatomic, strong) NSString<Optional> *note;

+ (PHRSample*)sampleFromBabyMilkModel:(BabyMilkModel*)babyMilkModel;

@end
