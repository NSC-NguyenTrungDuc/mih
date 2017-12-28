//
//  PresciptionObject.h
//  PHR
//
//  Created by BillyMobile on 5/21/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "OrderModel.h"

@interface PresciptionObject : NSObject

@property (nonatomic, strong) NSString *prescription_id;
@property (nonatomic, strong) NSString *prescription_name;
@property (nonatomic, strong) NSString *datetime_record;
@property (nonatomic, strong) NSString *prescription_url;
@property (nonatomic, strong) NSArray<OrderModel*> *listOrderModel;

+ (PresciptionObject *)initializeMedicinFrom:(NSDictionary *)dict;

@end
