//
//  LifeStyleNoteModel.h
//  PHR
//
//  Created by DEV-MinhNN on 1/29/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <JSONModel/JSONModel.h>
#import "PHRSample.h"

@interface LifeStyleNoteModel : JSONModel

@property (nonatomic, strong) NSString<Optional> *time_start_sleep;
@property (nonatomic, strong) NSString<Optional> *time_awake;
@property (nonatomic, strong) NSString<Optional> *time_wake_up;
@property (nonatomic, strong) NSString<Optional> *note;
@property (nonatomic, strong) NSString *total_hour_sleep;

@property (nonatomic, assign) int rating_sleep;
@property (nonatomic, assign) int id;
@property (nonatomic, assign) int profile_id;
- (PHRSample*)sampleFromModel:(LifeStyleNoteModel*)model;
- (instancetype)initFromSample:(PHRSample*)sample;
@end
