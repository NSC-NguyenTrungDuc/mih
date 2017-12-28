package nta.med.service.ihis.handler.bass;

import java.util.Calendar;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto.BAS0001U00GrdBAS0001Info;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0001U00ExecuteRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")  
@Transactional
public class BAS0001U00ExecuteHandler extends ScreenHandler<BassServiceProto.BAS0001U00ExecuteRequest, SystemServiceProto.UpdateResponse>{                             
	private static final Log LOGGER = LogFactory.getLog(BAS0001U00ExecuteHandler.class);                                        
	@Resource                                                                                                       
	private Bas0001Repository bas0001Repository;                                                                    
	                                                                                                                
	@Override
	@Route(global = true)
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, BAS0001U00ExecuteRequest request)
			throws Exception {                                                                   
      	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();  
      	   	String hospitalCode = request.getHospCode();
      	   	String language = getLanguage(vertx, sessionId);
      	   	List<Bas0001> listBas0001 = bas0001Repository.findLatestByHospCode(hospitalCode);
      	   	if(!CollectionUtils.isEmpty(listBas0001)){
      	   		response = executeHandler(request, hospitalCode, language, listBas0001.get(0));
      	   	}else{
      	   		response.setResult(false);
      	   	}
			return response.build();
	}
	
	public SystemServiceProto.UpdateResponse.Builder executeHandler(BassServiceProto.BAS0001U00ExecuteRequest request, String hospitalCode, String language, Bas0001 oldBas0001Info){
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		List<BAS0001U00GrdBAS0001Info> listItem = request.getItemInfoList();
		if(!CollectionUtils.isEmpty(listItem)){
			for(BAS0001U00GrdBAS0001Info item : listItem){
				if(DataRowState.ADDED.getValue().equals(item.getDataRowState())){
					String tDupCheck = bas0001Repository.getBAS0001U00ExecuteTDupCheck(hospitalCode, language, item.getStartDate(), item.getYoyangGiho());
					if(tDupCheck != null && tDupCheck.equals("Y")){
						response.setResult(false);
						return response;
					}
					//
					bas0001Repository.caseAddBAS0001U00ExecuteUpdateBAS0001(hospitalCode, language, request.getUserId(), 
							DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD), item.getYoyangGiho());
					//
					insertBas0001(request.getUserId(), hospitalCode, language, item, oldBas0001Info);
				} else if(DataRowState.MODIFIED.getValue().equals(item.getDataRowState())){
					List<Bas0001> listBas0001 = bas0001Repository.caseModifygetBas0001(hospitalCode, language,
							item.getStartDate(), item.getYoyangGiho());
					if(!CollectionUtils.isEmpty(listBas0001)){
						for(Bas0001 bas0001 : listBas0001){
							updateBas0001Item(request.getUserId(), item, bas0001);
						}
						bas0001Repository.save(listBas0001);
					}
				} else if(DataRowState.DELETED.getValue().equals(item.getDataRowState())){
					Calendar cal = Calendar.getInstance();
					cal.setTime(DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD));
					cal.add(Calendar.DATE, -1);
					Date endDate = cal.getTime();
					
					bas0001Repository.caseDeleteBAS0001U00ExecuteUpdateBAS0001(hospitalCode, language, endDate, item.getYoyangGiho());
					bas0001Repository.caseDeleteBAS0001U00ExecuteDeleteBAS0001(hospitalCode, language, item.getStartDate(), item.getYoyangGiho());
				}
			}
		}
		response.setResult(true);
		return response;
	}

	private void updateBas0001Item(String userId,
			BAS0001U00GrdBAS0001Info item, Bas0001 bas0001) {
		bas0001.setUpdId(userId);
		bas0001.setUpdDate(new Date());
		bas0001.setYoyangName(item.getYoyangName());
		bas0001.setYoyangName2(item.getYoyangName2());
		bas0001.setEndDate(DateUtil.toDate(item.getEndDate(), DateUtil.PATTERN_YYMMDD));
		bas0001.setZipCode1(item.getZipCode1());
		bas0001.setZipCode2(item.getZipCode2());
		bas0001.setZipCode(item.getZipCode1().concat(item.getZipCode2()));
		bas0001.setAddress(item.getAddress());
		bas0001.setAddress1(item.getAddress1());
		bas0001.setTel(item.getTel());
		bas0001.setTel1(item.getTel1());
		bas0001.setFax(item.getFax());
		bas0001.setTotBed(CommonUtils.parseDouble(item.getTotBed()));
		bas0001.setHomepage(item.getHomepage());
		bas0001.setEmail(item.getEmail());
		bas0001.setHospJinGubun(item.getHospJinGubun());
		bas0001.setDodobuhyeunNo(item.getDodobuhyeunNo());
		bas0001.setJaedanName(item.getJaedanName());
		bas0001.setSimpleYoyangName(item.getSimpleYoyangName());
		bas0001.setBankName(item.getBankName());
		bas0001.setBankJijum(item.getBankJijum());
		bas0001.setBankNo(item.getBankNo());
		bas0001.setAcctRefId(item.getAcctRefId());
		bas0001.setBankAccName(item.getBankAccName());
		bas0001.setPresidentName(item.getPresidentName());
	}

	private void insertBas0001(String userId, String hospitalCode, String language, BAS0001U00GrdBAS0001Info item, Bas0001 oldBas0001Info) {
		Bas0001 bas0001 =  new Bas0001();
		bas0001.setSysDate(new Date());
		bas0001.setSysId(userId);
		bas0001.setUpdDate(new Date());
		bas0001.setUpdId(userId);
		bas0001.setHospCode(hospitalCode);
		bas0001.setLanguage(language);
		bas0001.setStartDate(DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD));
		bas0001.setEndDate(DateUtil.toDate(item.getEndDate(), DateUtil.PATTERN_YYMMDD));
		bas0001.setYoyangGiho(item.getYoyangGiho());
		bas0001.setYoyangName(item.getYoyangName());
		bas0001.setYoyangName2(item.getYoyangName2());
		bas0001.setZipCode1(item.getZipCode1());
		bas0001.setZipCode2(item.getZipCode2());
		bas0001.setZipCode(item.getZipCode1().concat(item.getZipCode2()));
		bas0001.setAddress(item.getAddress());
		bas0001.setAddress1(item.getAddress1());
		bas0001.setTel(item.getTel());
		bas0001.setTel1(item.getTel1());
		bas0001.setFax(item.getFax());
		bas0001.setTotBed(CommonUtils.parseDouble(item.getTotBed()));
		bas0001.setHomepage(item.getHomepage());
		bas0001.setEmail(item.getEmail());
		bas0001.setHospJinGubun(item.getHospJinGubun());
		bas0001.setDodobuhyeunNo(item.getDodobuhyeunNo());
		bas0001.setJaedanName(item.getJaedanName());
		bas0001.setSimpleYoyangName(item.getSimpleYoyangName());
		bas0001.setBankName(item.getBankName());
		bas0001.setBankJijum(item.getBankJijum());
		bas0001.setBankNo(item.getBankNo());
		bas0001.setBankAccName(item.getBankAccName());
		bas0001.setOrcaGigwanCode(item.getOrcaGigwanCode());
		bas0001.setAcctRefId(item.getAcctRefId());
		bas0001.setShardingId(oldBas0001Info.getShardingId());
		bas0001.setHospSysId(oldBas0001Info.getHospSysId());
		bas0001.setHospGroupCd(oldBas0001Info.getHospGroupCd());
		bas0001.setRevision(oldBas0001Info.getRevision());
		bas0001.setPresidentName(item.getPresidentName());
		bas0001.setVpnYn(item.getVpnYn());
		bas0001.setTimeZone(CommonUtils.parseInteger(item.getTimeZone()));
		bas0001Repository.save(bas0001);
	}
}