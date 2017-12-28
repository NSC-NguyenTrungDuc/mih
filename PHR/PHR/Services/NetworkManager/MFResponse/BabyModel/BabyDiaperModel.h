//
//  BabyDiaperModel.h
//  PHR
//
//  Created by DEV-MinhNN on 11/16/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <JSONModel/JSONModel.h>

@protocol BabyDiaperModel
@end

@interface BabyDiaperModel : JSONModel

@property (nonatomic, strong) NSString<Optional> *id;
@property (nonatomic, strong) NSString<Optional> *alert;
@property (nonatomic, strong) NSString<Optional> *color;
@property (nonatomic, strong) NSString<Optional> *method;
@property (nonatomic, strong) NSString<Optional> *note;
@property (nonatomic, strong) NSString<Optional> *state;
@property (nonatomic, strong) NSString<Optional> *time_pee_poo;
@property (nonatomic, strong) NSString<Optional> *profile_id;

@end
