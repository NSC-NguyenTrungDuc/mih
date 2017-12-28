//
//  FoodChildrenListHeaderTableViewCell.h
//  PHR
//
//  Created by NextopHN on 3/23/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface FoodChildrenListHeaderTableViewCell : UITableViewCell
@property (weak, nonatomic) IBOutlet UILabel *labelToday;
@property (weak, nonatomic) IBOutlet UILabel *labelMorning;
@property (weak, nonatomic) IBOutlet UILabel *labelNoon;
@property (weak, nonatomic) IBOutlet UILabel *labelNight;
@property (weak, nonatomic) IBOutlet UIView *viewMNE;
@property (weak, nonatomic) IBOutlet UIView *viewRoundEdge;
@property (weak, nonatomic) IBOutlet UILabel *labelNotToday;
@property (weak, nonatomic) IBOutlet UIView *viewTodayHighlight;
- (void)setStyleToHeaderTableViewWithTitle:(NSString *)titleBtn withData:(NSMutableArray*)foodArray;
@end
