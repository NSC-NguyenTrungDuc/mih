//
//  PHRBookingHistoryModel.m
//  PHR
//
//  Created by Dao Xuan Tu on 11/12/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "PHRBookingHistoryModel.h"

@implementation PHRBookingHistoryModel

- (instancetype)initWithDictionary:(NSDictionary *)data {
  self = [super init];
  if (self) {
      self.mtHistoryId = [Validator getSafeString:data[@"mt_history_id"]];
      self.rowNum = [Validator getSafeString:data[@"row_num"]];
      self.department = [Validator getSafeString:data[@"department"]];
      self.examinationDateTime = [Validator getSafeString:data[@"examination_date_time"]];
      self.mtHistoryUrl = [Validator getSafeString:data[@"mt_history_url"]];
      self.duration = [Validator getSafeString:data[@"duration"]];
      self.mediaState = MediaStateNone;
  }
  
  return self;
}

@end
