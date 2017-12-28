//
//  BluetoothDeviceHeader.m
//  PHR
//
//  Created by BillyMobile on 6/11/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "BluetoothDeviceHeader.h"

@implementation BluetoothDeviceHeader

- (void)awakeFromNib {
    [super awakeFromNib];
    self.lblDeviceType.font = [FontUtils aileronRegularWithSize:16.0];
    self.backgroundColor = [UIColor colorWithRed:242.0/255.0 green:242.0/255.0 blue:242.0/255.0 alpha:1.0];
    // Initialization code
}

/*
// Only override drawRect: if you perform custom drawing.
// An empty implementation adversely affects performance during animation.
- (void)drawRect:(CGRect)rect {
    // Drawing code
}
*/

@end
