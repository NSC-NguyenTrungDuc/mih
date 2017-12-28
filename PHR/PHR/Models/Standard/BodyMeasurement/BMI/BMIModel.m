//
//  BMIModel.m
//  PHR
//
//  Created by NextopHN on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "BMIModel.h"

@implementation BMIModel
- (id)initWithBMI:(float)bmi date:(NSString*)date{
    self = [super init];
    if (self) {
        self.BMI = bmi;
        self.date = date;
    }
    return self;
}

- (instancetype)initWithDictionary:(NSDictionary *)data{
    self = [super init];
    if (self) {
        [self updateWithDictionary:data];
    }
    
    return self;
}

+ (instancetype)initBMIWithObj:(NSDictionary *)objBMI {
    BMIModel *result = [[BMIModel alloc] initWithDictionary:objBMI];
    return result;
}

- (void)updateWithDictionary:(NSDictionary*)data{
    self.bmiID = [Validator getSafeString:data[KEY_ID]];
    self.BMI = [[Validator getSafeString:data[KEY_BMI]] floatValue];
    self.date = [Validator getSafeString:data[KEY_DateRecord]];
}
@end
