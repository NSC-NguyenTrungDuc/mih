//
//  Child.h
//  PHR
//
//  Created by DEV-CongHT on 10/12/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Profile.h"
#import "BabyGrowth.h"

@interface ProfileBaby : Profile {
    
}
@property (nonatomic, strong) BabyGrowth *growth;
@property (nonatomic, strong) NSString *nickName;

- (instancetype)initWithProfile:(Profile*)profile;
- (instancetype)initWithDictionary:(NSDictionary *)data;
- (void)updateWithDictionary:(NSDictionary*)data;


@end
