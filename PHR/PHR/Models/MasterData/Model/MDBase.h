//
//  MDBase.h
//  PHR
//
//  Created by Luong Le Hoang on 6/2/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Realm/Realm.h>

typedef NS_ENUM(NSInteger, MDGender) {
    MDGenderMale,
    MDGenderFemale
};

// Master data base
@interface MDBase : RLMObject

@property (assign, nonatomic) int age;
@property (assign, nonatomic) double mean; // standard value: giá trị tiêu chuẩn
@property (assign, nonatomic) double sd;    // amplitude: biên độ
@property (assign, nonatomic) MDGender gender; // 0 - boy, 1 - girl

- (void)setAgeMeanSdValues:(NSArray*)array;

@end
