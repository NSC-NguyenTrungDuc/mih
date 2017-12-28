//
//  BodyFatModel.m
//  PHR
//
//  Created by NextopHN on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "BodyFatModel.h"

@implementation BodyFatModel
- (id)initWithBodyFat:(float)fat date:(NSString*)date{
    self = [super init];
    if (self) {
        self.bodyFat = fat;
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

+ (instancetype)initBodyFatWithObj:(NSDictionary *)objBodyFat {
    BodyFatModel *result = [[BodyFatModel alloc] initWithDictionary:objBodyFat];
    return result;
}

- (void)updateWithDictionary:(NSDictionary*)data{
     self.bodyFatID = [Validator getSafeString:data[KEY_ID]];
    self.bodyFat = [[Validator getSafeString:data[KEY_PercentageFat]] floatValue];
    self.date = [Validator getSafeString:data[KEY_DateRecord]];
}
@end
