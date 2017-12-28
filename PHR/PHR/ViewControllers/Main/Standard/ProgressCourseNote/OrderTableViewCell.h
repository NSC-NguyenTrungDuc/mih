//
//  OrderTableViewCell.h
//  PHR
//
//  Created by NextopHN on 4/15/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface OrderTableViewCell : UITableViewCell
@property (weak, nonatomic) IBOutlet UILabel *labelInputGubunName;
@property (weak, nonatomic) IBOutlet UILabel *labelHangmogName;
@property (weak, nonatomic) IBOutlet UILabel *labelOrderGubunName;
@property (weak, nonatomic) IBOutlet UILabel *labelContent;
@property (weak, nonatomic) IBOutlet UILabel *labelDosage;
@property (weak, nonatomic) IBOutlet UIView *viewBorder;
@end
