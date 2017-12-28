//
//  BabyMilk.h
//  PHR
//
//  Created by DEV-MinhNN on 11/5/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "BabyMilkModel.h"

@interface BabyMilk : NSObject

@property (nonatomic) int id_milk;
@property (nonatomic) int alert;
@property (nonatomic, strong) NSString *drink_method;
@property (nonatomic, strong) NSString *time_drink_milk;
@property (nonatomic, strong) NSString *breast_time;
@property (nonatomic, strong) NSString *bottle_milk_volume;
@property (nonatomic, strong) NSString *kcal;
@property (nonatomic, strong) NSString *milk_type;
@property (nonatomic, strong) NSString *note;
@property (nonatomic, strong) NSString *dateTime;

+ (BabyMilk *)initializeBabyMilkFromObj:(NSDictionary *)dict andDate:(NSString *)date;
+ (BabyMilk *)initializeBabyMilkFromModel:(BabyMilkModel *)model andDate:(NSString *)date;

@end
