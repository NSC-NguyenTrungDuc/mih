//
//  Member.m
//  PHR
//
//  Created by DEV-CongHT on 10/10/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "ProfileStandard.h"

@implementation ProfileStandard{
    
}

- (instancetype)initWithDictionary:(NSDictionary *)data{
    self = [super initWithDictionary:data];
    if (self) {
        [self updateWithDictionary:data];
    }
    
    return self;
}

- (void)encodeWithCoder:(NSCoder *)encoder{
    [super encodeWithCoder:encoder];
    [encoder encodeObject:self.zipCode forKey:KEY_ZipCode];
    [encoder encodeObject:self.prefecture forKey:KEY_Prefecture];
    [encoder encodeObject:self.city forKey:KEY_City];
    [encoder encodeObject:self.address forKey:KEY_Address];
    [encoder encodeObject:self.occupation forKey:KEY_Occupation];
}

- (id)initWithCoder:(NSCoder *)decoder {
    self = [super initWithCoder:decoder];
    if (self) {
        self.zipCode = [decoder decodeObjectForKey:KEY_ZipCode];
        self.prefecture = [decoder decodeObjectForKey:KEY_Prefecture];
        self.city = [decoder decodeObjectForKey:KEY_City];
        self.address = [decoder decodeObjectForKey:KEY_Address];
        self.occupation = [decoder decodeObjectForKey:KEY_Occupation];
    }
    return self;
}

- (void)updateWithDictionary:(NSDictionary*)data{
    [super updateWithDictionary:data];
    self.zipCode = [Validator getSafeString:data[KEY_ZipCode]];
    self.prefecture = [Validator getSafeString:data[KEY_Prefecture]];
    self.city = [Validator getSafeString:data[KEY_City]];
    self.address = [Validator getSafeString:data[KEY_Address]];
    self.occupation = [Validator getSafeString:data[KEY_Occupation]];
    NSString *memberType = [Validator getSafeString:data[KEY_FamilyMemberType]];
    self.isMainProfile = memberType && [memberType isEqualToString:KEY_FAMILY_TYPE_PERSONAL];
    // List clinic account
    self.listClinicAccount = [[NSMutableArray alloc] init];
    if (data[KEY_ListAccountClinic] && data[KEY_ListAccountClinic] != [NSNull null]) {
        NSArray *arrayClinic = data[KEY_ListAccountClinic];
        for (NSDictionary *dictAccount in arrayClinic) {
            ClinicAccount *acc = [[ClinicAccount alloc] initWithDict:dictAccount];
            [self.listClinicAccount addObject:acc];
        }
    }
}

- (void)removeClinicAccountId:(NSString*)clinicId{
    if (self.listClinicAccount && self.listClinicAccount.count > 0){
        for (NSInteger i = self.listClinicAccount.count - 1; i >= 0; i--) {
            ClinicAccount *acc = self.listClinicAccount[i];
            if ([acc.clinicId isEqualToString:clinicId]) {
                [self.listClinicAccount removeObjectAtIndex:i];
                break;
            }
        }
    }
}

@end
