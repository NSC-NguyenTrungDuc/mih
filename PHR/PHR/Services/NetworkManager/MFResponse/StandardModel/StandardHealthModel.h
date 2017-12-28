//
//  StandardHealthModel.h
//  PHR
//
//  Created by NextopHN on 2/3/16.
//  Copyright © 2016 Sofia. All rights reserved.
//
#import <JSONModel/JSONModel.h>

@interface StandardHealthModel : JSONModel
    @property (nonatomic, strong) NSString<Optional> *id;
    @property (nonatomic, strong) NSString<Optional> *weight;
    @property (nonatomic, strong) NSString<Optional> *height;
    @property (nonatomic, strong) NSString<Optional> *waist_line;
    @property (nonatomic, strong) NSString<Optional> *chest_size;
    @property (nonatomic, strong) NSString<Optional> *low_blood_press;
    @property (nonatomic, strong) NSString<Optional> *high_blood_press;
    @property (nonatomic, strong) NSString<Optional> *perc_fat;
    @property (nonatomic, strong) NSString<Optional> *bmi;
    @property (nonatomic, strong) NSString<Optional> *note;
    @property (nonatomic, strong) NSString<Optional> *datetime_record;
    @property (nonatomic, strong) NSString<Optional> *profile_id;
@end


