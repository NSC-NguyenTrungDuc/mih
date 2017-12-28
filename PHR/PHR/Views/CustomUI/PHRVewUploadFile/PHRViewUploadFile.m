//
//  PHRViewUploadFile.m
//  PHR
//
//  Created by DEV-MinhNN on 11/30/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "PHRViewUploadFile.h"

@implementation PHRViewUploadFile

/*
 // Only override drawRect: if you perform custom drawing.
 // An empty implementation adversely affects performance during animation.
 - (void)drawRect:(CGRect)rect {
 // Drawing code
 }
 */

- (void)addViewContainFileServerInParentView:(NSArray *)arrayFileImage {
    int originY = 0.0;
    _listImage = [NSMutableArray new];
    
    for (int i = 0; i < arrayFileImage.count; i++) {
        UIView *subView = [[UIView alloc] initWithFrame:CGRectMake(0.0, originY, self.frame.size.width, 152.0)];
        
        NSString *objImg = [arrayFileImage objectAtIndex:i];
        UIImageView *imgView = [[UIImageView alloc] init];
        
        [imgView setAccessibilityIdentifier:[objImg lastPathComponent]];
        [imgView sd_setImageWithURL:[NSURL URLWithString:objImg] placeholderImage:[UIImage imageNamed:PHR_ICON_UPLOAD_FILE] options:SDWebImageRefreshCached];
        [imgView setFrame:CGRectMake(0.0, 0.0, PHR_SIZE_IMG, PHR_SIZE_IMG)];

        UITapGestureRecognizer *tapGestureRecognizer = [[UITapGestureRecognizer alloc] initWithTarget:self action:@selector(labelTapped:)];
        tapGestureRecognizer.numberOfTapsRequired = 1;
        
        UIButton *btnTap = [UIButton buttonWithType:UIButtonTypeRoundedRect];
        [btnTap addTarget:self action:@selector(nameImageTapped:) forControlEvents:UIControlEventTouchUpInside];
        [btnTap setFrame:CGRectMake(20.0, 0.0, SCREEN_WIDTH - 60.0, 15.0)];
        [btnTap setTitle:[objImg lastPathComponent] forState:UIControlStateNormal];
        btnTap.tag = i;
        
        btnTap.contentHorizontalAlignment = UIControlContentHorizontalAlignmentLeft;
        [btnTap.titleLabel setStyleRegularToLabelWithColor:RGBCOLOR(35.0, 131.0, 152.0) andSize:11.0];
        [subView addSubview:btnTap];
        
        imgView.userInteractionEnabled = YES;
        [imgView addGestureRecognizer:tapGestureRecognizer];
        
        UIView *separatorView = [[UIView alloc] init];
        [separatorView setStyleRegularToViewWithAlpha:0.5];
        [separatorView setFrame:CGRectMake(0.0, PHR_SIZE_IMG + 3.0, self.frame.size.width, 1.0)];
        
        UIButton *btnDelete = [UIButton buttonWithType:UIButtonTypeCustom];
        [btnDelete setImage:[UIImage imageNamed:PHR_ICON_DELETE_FILE] forState:UIControlStateNormal];
        [btnDelete addTarget:self action:@selector(pressDeleteFileUpload:) forControlEvents:UIControlEventTouchUpInside];
        [btnDelete setFrame:CGRectMake(self.frame.size.width - 20.0, 0.0, 16.0, 16.0)];
        btnDelete.tag = i;
        
        originY += 25.0;
        
        if (i != arrayFileImage.count - 1) {
            [subView addSubview:separatorView];
        }
        
        [_listImage addObject:imgView];
        [subView addSubview:btnDelete];
        [subView addSubview:imgView];
        [self addSubview:subView];
    }
}

- (void)addViewNameFileUploadInParentView:(NSArray *)arrayFileNameUpload andListFileName:(NSMutableArray *)arrayFileName {
    int originY = 0.0;
    _listImage = [NSMutableArray new];
    for (id subView in self.subviews) {
        if ([subView isKindOfClass:[UIView class]]) {
            [subView removeFromSuperview];
        }
    }
    
    ALAssetsLibrary *library = [[ALAssetsLibrary alloc] init];
    
    for (int i = 0; i < arrayFileNameUpload.count; i++) {
        UIView *subView = [[UIView alloc] initWithFrame:CGRectMake(0.0, originY, self.frame.size.width, 152.0)];
        
        NSURL *objImg = [arrayFileNameUpload objectAtIndex:i];
        NSString *checkURL = [NSString stringWithFormat:@"%@", objImg];
        
        UIImageView *imgView = [[UIImageView alloc] init];
        
        if ([checkURL rangeOfString:@"assets-library"].location == NSNotFound) {
            [imgView sd_setImageWithURL:objImg placeholderImage:[UIImage imageNamed:PHR_ICON_UPLOAD_FILE] options:SDWebImageRefreshCached];
        }
        else {
            [library assetForURL:objImg
                     resultBlock:^(ALAsset *asset) {
                         imgView.image = [UIImage imageWithCGImage:[[asset defaultRepresentation] fullScreenImage]];
                     }
                    failureBlock:^(NSError *error){ NSLog(@"operation was not successfull!"); } ];
        }
        
        NSString *nameFile = [arrayFileName objectAtIndex:i];
        [imgView setAccessibilityIdentifier:[NSString stringWithFormat:@"%@", nameFile]];
        [imgView setFrame:CGRectMake(0.0, 0.0, PHR_SIZE_IMG, PHR_SIZE_IMG)];
        
        UITapGestureRecognizer *tapGestureRecognizer = [[UITapGestureRecognizer alloc] initWithTarget:self action:@selector(labelTapped:)];
        tapGestureRecognizer.numberOfTapsRequired = 1;
        
        UIButton *btnTap = [UIButton buttonWithType:UIButtonTypeRoundedRect];
        [btnTap addTarget:self action:@selector(nameImageTapped:) forControlEvents:UIControlEventTouchUpInside];
        [btnTap setFrame:CGRectMake(20.0, 0.0, SCREEN_WIDTH - 60.0, 15.0)];
        [btnTap setTitle:nameFile forState:UIControlStateNormal];
        btnTap.tag = i;
        
        btnTap.contentHorizontalAlignment = UIControlContentHorizontalAlignmentLeft;
        [btnTap.titleLabel setStyleRegularToLabelWithColor:RGBCOLOR(35.0, 131.0, 152.0) andSize:11.0];
        [subView addSubview:btnTap];
        
        UIView *separatorView = [[UIView alloc] init];
        [separatorView setStyleRegularToViewWithAlpha:0.5];
        [separatorView setFrame:CGRectMake(0.0, PHR_SIZE_IMG + 3.0, self.frame.size.width, 1.0)];
        
        UIButton *btnDelete = [UIButton buttonWithType:UIButtonTypeCustom];
        [btnDelete setImage:[UIImage imageNamed:PHR_ICON_DELETE_FILE] forState:UIControlStateNormal];
        [btnDelete addTarget:self action:@selector(pressDeleteFileUpload:) forControlEvents:UIControlEventTouchUpInside];
        [btnDelete setFrame:CGRectMake(self.frame.size.width - 20.0, 0.0, 16.0, 16.0)];
        btnDelete.tag = i;
        
        originY += 25.0;
        
        if (i != arrayFileNameUpload.count - 1) {
            [subView addSubview:separatorView];
        }
        
        [_listImage addObject:imgView];
        [subView addSubview:btnDelete];
        [subView addSubview:imgView];
        [self addSubview:subView];
    }
}

- (void)pressDeleteFileUpload:(UIButton *)btn {
    UIView *subView = [self.subviews objectAtIndex:btn.tag];
    if (subView) {
        [subView removeFromSuperview];
    }
    for (UIView *subView2 in self.subviews) {
        for (id subBtn in subView2.subviews) {
            if ([subBtn isKindOfClass:[UIButton class]]) {
                UIButton *btn2 = (UIButton *)subBtn;
                if (btn2.tag > btn.tag) {
                    btn2.tag -= 1;
                }
            }
        }
    }
    
    if (self.delegate && [self.delegate respondsToSelector:@selector(deleteFileUpload:)]) {
        [self.delegate performSelector:@selector(deleteFileUpload:) withObject:btn];
    }
}

#pragma mark - Method Tap

- (void)labelTapped:(UITapGestureRecognizer *)recognizer {
    UIView *view = [recognizer view];
    if ([view isKindOfClass:[UIImageView class]]) {
        UIImageView *imageView = (UIImageView *)view;
        if (self.delegate && [self.delegate respondsToSelector:@selector(showImage:)]) {
            [self.delegate performSelector:@selector(showImage:) withObject:imageView];
        }
    }
}

- (void)nameImageTapped:(UIButton *)sender {
    UIImageView *imageView = [_listImage objectAtIndex:sender.tag];
    if (self.delegate && [self.delegate respondsToSelector:@selector(showImage:)]) {
        [self.delegate performSelector:@selector(showImage:) withObject:imageView];
    }
}

@end
