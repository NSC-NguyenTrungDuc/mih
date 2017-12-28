//
//  ERMTag.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/27/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "EMRTag.h"

@implementation EMRTag

- (instancetype)initWithDictionary:(NSDictionary *)data {
    self = [super init];
    if (self) {
        [self updateWithDictionary:data];
    }
    return self;
}

+ (instancetype)initWithObj:(NSDictionary *)obj {
    EMRTag *result = [[EMRTag alloc] initWithDictionary:obj];
    return result;
}

- (void)updateWithDictionary:(NSDictionary*)data {
    self.tagCode = [Validator getSafeString:data[KEY_EMR_Tag_Code]];
    self.tagName = [Validator getSafeString:data[KEY_EMR_Tag_Name]];
}

@end
