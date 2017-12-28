//
//  MenuLeftViewController.h
//  PHR
//
//  Created by Luong Le Hoang on 9/29/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

@protocol MenuLeftViewControllerDelegate <NSObject>
- (void)menuLeftLogout;
@end


@interface MenuLeftViewController : UIViewController <UITableViewDelegate, UITableViewDataSource>{
    
}
@property (nonatomic, weak) id<MenuLeftViewControllerDelegate> delegate;
@property (weak, nonatomic) IBOutlet UILabel *labelSetting;
@property (weak, nonatomic) IBOutlet UIButton *btnBackToDashboard;
@property (weak, nonatomic) IBOutlet UITableView *tableMenu;
@property (weak, nonatomic) IBOutlet UIActivityIndicatorView *viewIndicator;
- (IBAction)actionBackToDashbroad:(id)sender;

@end
