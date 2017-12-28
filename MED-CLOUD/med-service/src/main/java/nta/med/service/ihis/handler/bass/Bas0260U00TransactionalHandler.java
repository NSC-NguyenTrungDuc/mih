package nta.med.service.ihis.handler.bass;

import java.util.Calendar;
import java.util.Date;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.bas.Bas0260;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto.BAS0260GrdBuseoListItemInfo;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.Bas0260U00TransactionalRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Transactional
@Service                                                                                                          
@Scope("prototype")                                                                                 
public class Bas0260U00TransactionalHandler extends ScreenHandler<BassServiceProto.Bas0260U00TransactionalRequest, SystemServiceProto.UpdateResponse> {                             
	
	private static final Log LOGGER = LogFactory.getLog(Bas0260U00TransactionalHandler.class);                                        
	
	@Resource                                                                                                       
	private Bas0260Repository bas0260Repository;                                                                    
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, Bas0260U00TransactionalRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			Bas0260U00TransactionalRequest request) throws Exception {                 
		String hospCode = request.getHospCode();
		String language = getLanguage(vertx, sessionId);
  	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();   
  	   	if(!CollectionUtils.isEmpty(request.getGrdBuseoListList())) {
				for(BAS0260GrdBuseoListItemInfo item : request.getGrdBuseoListList()){
					if(item.getRowSate().equalsIgnoreCase(DataRowState.ADDED.getValue())){
						String updateCheck = bas0260Repository.getBas0260U00TransactionUpdatecheck(hospCode, item.getBuseoCode(), item.getStartDate(), language);
						if(!StringUtils.isEmpty(updateCheck)){
							response.setResult(updateBas0260U00(item, request.getUserId(), hospCode, language));
						}
						Boolean isDuplicateKey = bas0260Repository.isExistedBAS0260(hospCode, item.getBuseoCode(), item.getStartDate(), language);
						if (isDuplicateKey) {
							response.setResult(false);
							response.setMsg("duplicate");
						} else {
							response.setResult(insertBas0260U00(item, request.getUserId(), hospCode, language));
						}
					}else if(item.getRowSate().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
						if(!updateBas0260U00Modified(item, request.getUserId(), hospCode, language)){
							response.setResult(false);
							throw new ExecutionException(response.build());
						}else{
							response.setResult(true);		
						}
					}else if(item.getRowSate().equalsIgnoreCase(DataRowState.DELETED.getValue())){
						updateBas0260U00Deleted(item, request.getUserId(), hospCode, language);
						if(!deleteBas0260U00Deleted(item, request.getUserId(), hospCode, language)){
							response.setResult(false);
							throw new ExecutionException(response.build());
						}else{
							response.setResult(true);
						}
					}
				}
			}                                                                                                                                                   
		return response.build();
		}																																						
	
	public boolean updateBas0260U00(BAS0260GrdBuseoListItemInfo item, String userId, String hospCode, String language){
		Calendar cal = Calendar.getInstance();
		cal.setTime(DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD));
		cal.add(Calendar.DATE, -1);
		Date endDate = cal.getTime();
		if(bas0260Repository.updateBas0260U00TransactionAdded(userId, hospCode, item.getBuseoCode(), endDate, item.getStartDate(), language)>0){
			return true;
		}else{
			return false;
		}
	}
	
	public boolean insertBas0260U00(BAS0260GrdBuseoListItemInfo item, String userId, String hospCode, String language){
		Bas0260 bas0260 = new Bas0260();
		bas0260.setSysDate(new Date());
		bas0260.setUpdDate(new Date());
		if(!StringUtils.isEmpty(userId)){
			bas0260.setUpdId(userId);
			bas0260.setSysId(userId);
		}
		bas0260.setHospCode(hospCode);
		bas0260.setBuseoCode(item.getBuseoCode());
		if(!StringUtils.isEmpty(item.getStartDate())){
			bas0260.setStartDate(DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD));
		}
		bas0260.setBuseoName(item.getBuseoName());
		bas0260.setBuseoGubun(item.getBuseoGubun());
		bas0260.setParentBuseo(StringUtils.isEmpty(item.getParentBuseo()) ? null : item.getParentBuseo());
		bas0260.setGwa(StringUtils.isEmpty(item.getGwa()) ? null : item.getGwa());
		bas0260.setGwaName(StringUtils.isEmpty(item.getGwaName()) ? null : item.getGwaName());
		bas0260.setParentGwa(StringUtils.isEmpty(item.getParentGwa()) ? null : item.getParentGwa());
		bas0260.setOutJubsuYn(item.getOutJubsuYn());
		bas0260.setIpwonYn(item.getIpwonYn());
		bas0260.setOutSlipYn(item.getOutSlipYn());
		bas0260.setInpSlipYn(item.getInpSlipYn());
		bas0260.setInputGubun(StringUtils.isEmpty(item.getInputGubun()) ? null : item.getInputGubun());
		bas0260.setOutMoveYn(item.getOutMoveYn());
		bas0260.setOutJundalPartYn(item.getOutJundalPartYn());
		bas0260.setInpJundalPartYn(item.getInpJundalPartYn());
		bas0260.setEuryoseoYn(item.getEuryoseoYn());
		bas0260.setTel(StringUtils.isEmpty(item.getTel()) ? null : item.getTel());
		bas0260.setGwaGubun(StringUtils.isEmpty(item.getGwaGubun()) ? null : item.getGwaGubun());
		bas0260.setMoveComment(item.getMoveComment());
		bas0260.setGwaSort2(CommonUtils.parseDouble(item.getGwaSort2()));
		bas0260.setGwaSort1(CommonUtils.parseDouble(item.getGwaSort1()));
		bas0260.setGwaEname(StringUtils.isEmpty(item.getGwaEname()) ? null : item.getGwaEname());
		bas0260.setGwaSname(StringUtils.isEmpty(item.getGwaSname()) ? null : item.getGwaSname());
		bas0260.setRmk(StringUtils.isEmpty(item.getRmk()) ? null : item.getRmk());
		if(!StringUtils.isEmpty(item.getEndDate())){
		bas0260.setEndDate(DateUtil.toDate(item.getEndDate(), DateUtil.PATTERN_YYMMDD));
		}
		bas0260.setBuseoName2(StringUtils.isEmpty(item.getBuseoName2()) ? null : item.getBuseoName2());
		bas0260.setGwaColor(StringUtils.isEmpty(item.getGwaColor()) ? null : item.getGwaColor());
		bas0260.setHpcHoDongYn(StringUtils.isEmpty(item.getHpcHoDongYn()) ? null : item.getHpcHoDongYn());
		bas0260.setAddDoctor(StringUtils.isEmpty(item.getAddDoctor()) ? null : item.getAddDoctor());
		bas0260.setGwaNameKana(StringUtils.isEmpty(item.getGwaNameKana()) ? null : item.getGwaNameKana());
		bas0260.setLanguage(language);
		bas0260.setUseYn(item.getUseYn());
		bas0260Repository.save(bas0260);
		return true;
	}
	
	public boolean updateBas0260U00Modified(BAS0260GrdBuseoListItemInfo item, String userId, String hospCode, String language){
		if(bas0260Repository.updateBas0260U00TransactionModified(
				userId,
				item.getBuseoName(),
				StringUtils.isEmpty(item.getParentBuseo()) ? null : item.getParentBuseo(),
				item.getBuseoGubun(),
				item.getGwaGubun(),
				StringUtils.isEmpty(item.getGwa()) ? null : item.getGwa(),
				StringUtils.isEmpty(item.getGwaName()) ? null : item.getGwaName(),
				StringUtils.isEmpty(item.getParentGwa()) ? null : item.getParentGwa(),
				item.getOutJubsuYn(),
				item.getIpwonYn(),
				item.getOutSlipYn(),
				item.getInpSlipYn(),
				item.getEuryoseoYn(),
				item.getOutMoveYn(),
				item.getOutJundalPartYn(),
				item.getInpJundalPartYn(),
				item.getInputGubun(),
				item.getMoveComment(),
				StringUtils.isEmpty(item.getTel()) ? null : item.getTel(),
				StringUtils.isEmpty(item.getGwaEname()) ? null : item.getGwaEname(),
				StringUtils.isEmpty(item.getGwaSname()) ? null : item.getGwaSname(),
				CommonUtils.parseDouble(item.getGwaSort1()),
				CommonUtils.parseDouble(item.getGwaSort2()),
				StringUtils.isEmpty(item.getRmk()) ? null : item.getRmk(),
				DateUtil.toDate(item.getEndDate(), DateUtil.PATTERN_YYMMDD),
				StringUtils.isEmpty(item.getBuseoName2()) ? null : item.getBuseoName2(),
				StringUtils.isEmpty(item.getGwaColor()) ? null : item.getGwaColor(),
				StringUtils.isEmpty(item.getHpcHoDongYn()) ? null : item.getHpcHoDongYn(),
				StringUtils.isEmpty(item.getAddDoctor()) ? null : item.getAddDoctor(),
				StringUtils.isEmpty(item.getGwaNameKana()) ? null : item.getGwaNameKana(),
				hospCode,
				item.getBuseoCode(),
				DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD),
				language,
				item.getUseYn()) > 0){
			return true;
		}else{
			return false;
		}
	}
	
	
	public boolean updateBas0260U00Deleted(BAS0260GrdBuseoListItemInfo item, String userId, String hospCode, String language){
			Calendar cal = Calendar.getInstance();
			cal.setTime(DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD));
			cal.add(Calendar.DATE, -1);
			Date endDate = cal.getTime();
		if(bas0260Repository.updateBas0260U00TransactionDeleted(
				userId, 
				new Date(),
				hospCode, 
				item.getBuseoCode(), 
				endDate, 
				language)>0){
			return true;
		}else {
			return false;
		}
	}
	
	public boolean deleteBas0260U00Deleted(BAS0260GrdBuseoListItemInfo item, String userId, String hospCode, String language){
		if(bas0260Repository.delete0260U00TransactionDeleted(
				hospCode,
				item.getBuseoCode(), 
				DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD), 
				language)>0){
			return true;
		}else {
			return false;
		}
	}
}