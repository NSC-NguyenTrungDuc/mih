package nta.med.service.ihis.handler.chts;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.cht.Cht0110;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.cht.Cht0110Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.ChtsModelProto.CHT0110U00grdCHT0110ItemInfo;
import nta.med.service.ihis.proto.ChtsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype") 
@Transactional
public class CHT0110U00ExecuteHandler extends ScreenHandler<ChtsServiceProto.CHT0110U00ExecuteRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOGGER = LogFactory.getLog(CHT0110U00ExecuteHandler.class);                                        
	@Resource                                                                                                       
	private Cht0110Repository cht0110Repository;

	@Override
	public boolean isValid(ChtsServiceProto.CHT0110U00ExecuteRequest request, Vertx vertx, String clientId, String sessionId) {
		String hospitalCode = getHospitalCode(vertx, sessionId);
		for(CHT0110U00grdCHT0110ItemInfo item: request.getItemInfoList()) {
			if (!StringUtils.isEmpty(item.getEndDate()) && DateUtil.toDate(item.getEndDate(), DateUtil.PATTERN_YYMMDD) == null) {
				return false;
			} else {
				if (DataRowState.ADDED.getValue().equals(item.getRowState())) {
					//check
					String tChk = cht0110Repository.getCHT0110U00TChk(hospitalCode, item.getSangCode());
					if (tChk != null && tChk.equals("Y")) {
						SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
						response.setResult(false);
						response.setMsg(item.getSangCode());
						throw new ExecutionException(response.build());
					}
				}
			}
		}
		return true;
	}

	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, ChtsServiceProto.CHT0110U00ExecuteRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
			Integer result = null;
		String hospitalCode = getHospitalCode(vertx, sessionId);
			for(CHT0110U00grdCHT0110ItemInfo item: request.getItemInfoList()){
				if(DataRowState.ADDED.getValue().equals(item.getRowState())){
					insertCHT0110(item, request.getUserId(), hospitalCode);
					result = 1;
				}else if(DataRowState.MODIFIED.getValue().equals(item.getRowState())){
					result=cht0110Repository.updateCHT0110U00(hospitalCode, request.getUserId(),
							item.getSangName(),item.getSangNameHan(),item.getSangNameSelf(),
							DateUtil.toDate(item.getEndDate(), DateUtil.PATTERN_YYMMDD)	,item.getBulyongYn(),item.getSangCode());
				}else if(DataRowState.DELETED.getValue().equals(item.getRowState())){
					result=cht0110Repository.deleteCHT0110U00(hospitalCode,item.getSangCode());
				}
			}
			response.setResult(result != null && result > 0);
		return response.build();
	}
	
	public void insertCHT0110(CHT0110U00grdCHT0110ItemInfo item, String userId, String hospitalCode){
		Cht0110 cht0110 = new Cht0110();	
		cht0110.setSysDate(new Date());
		cht0110.setSysId(userId);
		cht0110.setUpdDate(new Date());
		cht0110.setUpdId(userId);
		cht0110.setHospCode(hospitalCode);
		cht0110.setSangCode(item.getSangCode());
		cht0110.setSangName(item.getSangName());
		cht0110.setSangNameHan(item.getSangNameHan());
		cht0110.setSangNameInx(item.getSangCode() + " " + item.getSangName() + " " + item.getSangName() + " " + item.getSangNameHan());
		cht0110.setSangNameSelf(item.getSangNameSelf());
		cht0110.setStartDate(new Date());
		cht0110.setEndDate(DateUtil.toDate(!StringUtils.isEmpty(item.getEndDate()) ? item.getEndDate() : "9998/12/31", DateUtil.PATTERN_YYMMDD));
		cht0110.setBulyongYn(item.getBulyongYn());
		cht0110.setSugaSangCode(item.getSugaSangCode());
		cht0110.setJunyeomBunryu(item.getJunyeomBuryn());
		cht0110.setJunyeomKind(item.getJunyeomKind());
		cht0110.setSamangSangGroup(item.getSamangSangGroup());
		cht0110Repository.save(cht0110);
		
	}
}