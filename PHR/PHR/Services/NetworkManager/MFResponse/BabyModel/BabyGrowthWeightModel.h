//
//  BabyGrowthWeightModel.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 6/9/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <JSONModel/JSONModel.h>

@protocol BabyGrowthWeightModel
@end

@interface BabyGrowthWeightModel : JSONModel

@property (nonatomic, strong) NSString<Optional> *growth_id;
@property (nonatomic, strong) NSString<Optional> *datetime_record;
@property (nonatomic, strong) NSString<Optional> *height;
@property (nonatomic, strong) NSString<Optional> *doctor_note;
@property (nonatomic, strong) NSString<Optional> *parent_note;
@property (nonatomic, strong) NSString<Optional> *medical_record_url;
@property (nonatomic, strong) NSString<Optional> *type;
@end
