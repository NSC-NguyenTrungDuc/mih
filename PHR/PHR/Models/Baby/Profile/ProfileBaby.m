//
//  Child.m
//  PHR
//
//  Created by DEV-CongHT on 10/12/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "ProfileBaby.h"

@implementation ProfileBaby{
    
}

- (instancetype)init{
    if (self = [super init]) {
        self.growth = [[BabyGrowth alloc] init];
    }
    return self;
}

- (instancetype)initWithDictionary:(NSDictionary *)data{
    self = [super initWithDictionary:data];
    if (self) {
        [self updateWithDictionary:data];
    }
    
    return self;
}

- (id)initWithCoder:(NSCoder *)decoder {
    self = [super initWithCoder:decoder];
    if (self) {
        self.growth = [decoder decodeObjectForKey:KEY_BabyGrowthModel];
        self.nickName = [decoder decodeObjectForKey:KEY_NickName];
    }
    return self;
}

- (instancetype)initWithProfile:(Profile*)profile {
    self = [super initWithProfile:profile];
    if ([profile isMemberOfClass:[self class]]) {
        ProfileBaby *baby = (ProfileBaby*)profile;
        [self.growth updateFromGrowth:baby.growth];
        self.nickName = baby.nickName;
    }
    return self;
}

- (void)encodeWithCoder:(NSCoder *)encoder{
    [super encodeWithCoder:encoder];
    [encoder encodeObject:self.growth forKey:KEY_BabyGrowthModel];
}

- (void)updateWithDictionary:(NSDictionary*)data{
    [super updateWithDictionary:data];
    [self.growth updateWithDictionaryHeight:data[KEY_BabyGrowthHeightMode]];
    [self.growth updateWithDictionaryWeight:data[KEY_BabyGrowthWeightMode]];
    self.nickName = [Validator getSafeString:data[KEY_NickName]];
}

@end
