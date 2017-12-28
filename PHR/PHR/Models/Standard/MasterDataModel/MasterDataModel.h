//
//  MasterDataModel.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/22/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface MasterDataModel : NSObject

@property (nonatomic) float mean;
@property (nonatomic) float sd;
@property (nonatomic) float highMin;
@property (nonatomic) float normalMin;
@property (nonatomic) float normalMax;
@property (nonatomic) float highMax;
@property (nonatomic) float lowBPMean;
@property (nonatomic) float lowBPSD;
@property (nonatomic) float obesity;
@end
