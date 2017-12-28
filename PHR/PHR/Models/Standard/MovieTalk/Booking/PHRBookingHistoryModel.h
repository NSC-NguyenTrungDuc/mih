//
//  PHRBookingHistoryModel.h
//  PHR
//
//  Created by Dao Xuan Tu on 11/12/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>


@interface PHRBookingHistoryModel : NSObject

@property (nonatomic, strong) NSString *mtHistoryId;
@property (nonatomic, strong) NSString *rowNum;
@property (nonatomic, strong) NSString *department;
@property (nonatomic, strong) NSString *examinationDateTime;
@property (nonatomic, strong) NSString *mtHistoryUrl;
@property (nonatomic, strong) NSString *duration;
@property (assign, nonatomic) MediaState mediaState;

- (instancetype)initWithDictionary:(NSDictionary *)data;

@end
