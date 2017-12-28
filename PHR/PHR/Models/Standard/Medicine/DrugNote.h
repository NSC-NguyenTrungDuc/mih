//
//  DrugNote.h
//  PHR
//
//  Created by BillyMobile on 5/23/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "OrderModel.h"

@interface DrugNote : NSObject

@property (nonatomic, strong) NSString *drug_id;
@property (nonatomic, strong) NSString *drug_name;
@property (nonatomic, strong) NSString *dosage;
@property (nonatomic, strong) NSString *method;
@property (nonatomic, strong) NSString *dose;
@property (nonatomic, strong) NSString *note;
@property (nonatomic, strong) NSString *time;
@property (nonatomic, strong) NSString *unit;
@property (nonatomic) int quantity;
@property (nonatomic) int frequency;

+ (DrugNote *)initializeMedicinFrom:(NSDictionary *)dict;
+ (DrugNote*)initFromOrderModel:(OrderModel*)orderModel;

@end
