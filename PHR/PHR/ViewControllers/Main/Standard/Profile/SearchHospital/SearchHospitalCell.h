//
//  SearchHospitalCell.h
//  PHR
//
//  Created by Luong Le Hoang on 4/14/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface SearchHospitalCell : UITableViewCell
@property (weak, nonatomic) IBOutlet UILabel *labelName;
@property (weak, nonatomic) IBOutlet UILabel *labelAddress;
@property (weak, nonatomic) IBOutlet UILabel *labelTel;

- (void)fillInfoName:(NSString*)name address:(NSString*)address tel:(NSString*)tel;

@end
