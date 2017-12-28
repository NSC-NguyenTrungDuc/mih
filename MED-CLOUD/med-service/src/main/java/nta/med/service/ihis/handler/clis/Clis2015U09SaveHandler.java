package nta.med.service.ihis.handler.clis;

import java.math.BigDecimal;
import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.domain.clis.ClisSmo;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.clis.ClisSmoRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.ClisModelProto.CLIS2015U09ItemInfo;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U09SaveRequest;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;


@Transactional
@Service
@Scope("prototype")
public class Clis2015U09SaveHandler extends ScreenHandler<CLIS2015U09SaveRequest, UpdateResponse> {
	
	@Resource
	private ClisSmoRepository clisSmoRepository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CLIS2015U09SaveRequest request)
			throws Exception {
		UpdateResponse.Builder response = UpdateResponse.newBuilder();
		boolean save = false;
		if(!CollectionUtils.isEmpty(request.getDtList())){
			String hospCode = getHospitalCode(vertx, sessionId);
			String userId = getUserId(vertx, sessionId);
			for(CLIS2015U09ItemInfo item : request.getDtList()){
				if(item.getRowState().equals(DataRowState.ADDED.getValue())){
					save = insertClis2015U09(item, hospCode, userId);
				}else if(item.getRowState().equals(DataRowState.MODIFIED.getValue())){
					save = updateClis2015U09(item, hospCode, userId);
				}else if(item.getRowState().equals(DataRowState.DELETED.getValue())){
					save = deleteClis2015U09(item, userId);
				}
			}
		}
		response.setResult(save);
		return response.build();
	}
	
	private boolean insertClis2015U09(CLIS2015U09ItemInfo item, String hospCode, String userId){
		ClisSmo clisSmo = new ClisSmo();
		clisSmo.setStartDate(DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD));
		clisSmo.setEndDate(DateUtil.toDate(item.getEndDate(), DateUtil.PATTERN_YYMMDD));
		clisSmo.setSmoCode(item.getSmoCode());
		clisSmo.setSmoName(item.getSmoName());
		clisSmo.setSmoName1(item.getSmoName1());
		clisSmo.setZipCode1(item.getZipCode1());
		clisSmo.setZipCode2(item.getZipCode2());
		clisSmo.setAddress(item.getAddress());
		clisSmo.setAddress1(item.getAddress1());
		clisSmo.setTel(item.getTel());
		clisSmo.setTel1(item.getTel1());
		clisSmo.setFax(item.getFax());
		clisSmo.setDodobuhyeunNo(item.getDodobuhyeunNo());	
		clisSmo.setHomepage(item.getHomepage());
		clisSmo.setEmail(item.getEmail());
		clisSmo.setSysId(userId);
		clisSmo.setUpdId(userId);
		clisSmo.setCreated(new Date());
		clisSmo.setUpdated(new Date());
		clisSmo.setActiveFlg(new BigDecimal(1));
		clisSmo.setHospCode(hospCode);
		clisSmoRepository.save(clisSmo);
		return true;
	}

	private boolean updateClis2015U09(CLIS2015U09ItemInfo item, String hospCode, String userId){
		if(clisSmoRepository.updateClis2015U09Save(
				DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD), 
				DateUtil.toDate(item.getEndDate(), DateUtil.PATTERN_YYMMDD), 
				item.getSmoName(), 
				item.getSmoName1(), 
				item.getZipCode1(), 
				item.getZipCode2(), 
				item.getAddress(), 
				item.getAddress1(), 
				item.getTel(), 
				item.getTel1(), 
				item.getFax(), 
				item.getDodobuhyeunNo(), 
				item.getHomepage(), 
				item.getEmail(), 
				userId, 
				new Date(), 
				CommonUtils.parseInteger(item.getClisSmoId()))>0){
			return true;
		}else{
			return false;
		}
	}
	
	private boolean deleteClis2015U09(CLIS2015U09ItemInfo item, String userId){
		if(clisSmoRepository.deleteClis2015U09Save(
				new Date(),
				userId,
				new BigDecimal(0),
				CommonUtils.parseInteger(item.getClisSmoId()))>0){
			return true;
		}else{
			return false;
		}
	}
}
