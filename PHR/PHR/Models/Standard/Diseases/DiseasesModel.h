//
//  DiseasesModel.h
//  PHR
//
//  Created by DEV-MinhNN on 1/28/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <JSONModel/JSONModel.h>

@protocol DiseasesModel
@end

@interface DiseasesModel : JSONModel

@property (nonatomic, strong) NSString<Optional> *disease_id;
@property (nonatomic, strong) NSString<Optional> *datetime_record;
@property (nonatomic, strong) NSString<Optional> *hospital;
@property (nonatomic, strong) NSString<Optional> *disease_name;
@property (nonatomic, strong) NSString<Optional> *start_date;
@property (nonatomic, strong) NSString<Optional> *end_date;
@property (nonatomic, strong) NSString<Optional> *outcome;

@end
