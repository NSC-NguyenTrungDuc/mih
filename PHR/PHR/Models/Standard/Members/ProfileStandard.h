//
//  Member.h
//  PHR
//
//  Created by DEV-CongHT on 10/10/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Profile.h"
#import "ClinicAccount.h"

@interface ProfileStandard : Profile{
    
}
@property (strong, nonatomic) NSString *zipCode;
@property (strong, nonatomic) NSString *prefecture;
@property (strong, nonatomic) NSString *city;
@property (strong, nonatomic) NSString *address;
@property (strong, nonatomic) NSString *occupation;
@property (strong, nonatomic) NSMutableArray<ClinicAccount*> *listClinicAccount;
@property (assign, nonatomic) BOOL isMainProfile; // Profile of person, who create account

- (instancetype)initWithDictionary:(NSDictionary *)data;
- (void)removeClinicAccountId:(NSString*)clinicId;

@end
