//
//  BabyGrowthModel.h
//  PHR
//
//  Created by DEV-MinhNN on 11/16/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <JSONModel/JSONModel.h>

@protocol BabyGrowthModel
@end

@interface BabyGrowthModel : JSONModel

@property (nonatomic, strong) NSString<Optional> *growth_id;
@property (nonatomic, strong) NSString<Optional> *doctor_note;
@property (nonatomic, strong) NSString<Optional> *head_size;
@property (nonatomic, strong) NSString<Optional> *height;
@property (nonatomic, strong) NSString<Optional> *medical_record_url;
@property (nonatomic, strong) NSString<Optional> *parent_note;
@property (nonatomic, strong) NSString<Optional> *time_measure;
@property (nonatomic, strong) NSString<Optional> *profile_id;
@property (nonatomic, strong) NSString<Optional> *weight;
@property (nonatomic, strong) NSNumber<Optional> *type;


@end
