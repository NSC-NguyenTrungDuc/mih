//
//  Diaper.h
//  PHR
//
//  Created by DEV-MinhNN on 11/9/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "BabyDiaperModel.h"

@interface Diaper : NSObject

@property (nonatomic, strong) NSString *diaperID;
@property (nonatomic, strong) NSString *time_pee_poo;
@property (nonatomic, strong) NSString *alert;
@property (nonatomic, strong) NSString *method;
@property (nonatomic, strong) NSString *state;
@property (nonatomic, strong) NSString *color;
@property (nonatomic, strong) NSString *note;
@property (nonatomic, strong) NSString *dateTime;

+ (NSArray*)arrayState;
+ (Diaper *)initializeDiaperFrom:(NSDictionary *)dict;
+ (Diaper *)initializeDiaperFromModel:(BabyDiaperModel *)model andDate:(NSString *)date;

@end
