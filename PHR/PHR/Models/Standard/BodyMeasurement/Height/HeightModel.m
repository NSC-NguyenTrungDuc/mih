//
//  HeightModel.m
//  PHR
//
//  Created by NextopHN on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "HeightModel.h"

@implementation HeightModel
- (id)initWithHeight:(float)height date:(NSString*)date {
    self = [super init];
    if (self) {
        self.height = height;
        self.date = date;
    }
    return self;
}

- (instancetype)initWithDictionary:(NSDictionary *)data {
    self = [super init];
    if (self) {
        [self updateWithDictionary:data];
    }
    
    return self;
}

+ (instancetype)initHeightWithObj:(NSDictionary *)objHeight {
    HeightModel *result = [[HeightModel alloc] initWithDictionary:objHeight];
    return result;
}

- (void)updateWithDictionary:(NSDictionary*)data{
    self.heightID = [Validator getSafeString:data[KEY_ID]];
    self.height = [[Validator getSafeString:data[KEY_Height]] floatValue];
    self.date = [Validator getSafeString:data[KEY_DateRecord]];
}

@end
