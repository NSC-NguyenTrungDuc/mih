//
//  WeightModel.m
//  PHR
//
//  Created by NextopHN on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "WeightModel.h"

@implementation WeightModel
- (id)initWithWeight:(float)weight date:(NSString*)date{
    self = [super init];
    if (self) {
        self.weight = weight;
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

+ (instancetype)initWeightWithObj:(NSDictionary *)objWeight {
    WeightModel *result = [[WeightModel alloc] initWithDictionary:objWeight];
    return result;
}

- (void)updateWithDictionary:(NSDictionary*)data {
    self.weightID = [Validator getSafeString:data[KEY_ID]];
    self.weight = [[Validator getSafeString:data[KEY_Weight]] floatValue];
    self.date = [Validator getSafeString:data[KEY_DateRecord]];
}
@end
