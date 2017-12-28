package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.dao.medi.inp.Inp1003Repository;
import nta.med.data.dao.medi.nur.Nur0112Repository;
import nta.med.data.dao.medi.ocs.Ocs2005Repository;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;
import nta.med.data.model.ihis.ocsi.OCS2005U02ValidationCheckInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02ValidationCheckRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02ValidationCheckResponse;

@Service
@Scope("prototype")
public class OCS2005U02ValidationCheckHandler extends
		ScreenHandler<OcsiServiceProto.OCS2005U02ValidationCheckRequest, OcsiServiceProto.OCS2005U02ValidationCheckResponse> {
	
	@Resource
	private Ocs2005Repository ocs2005Repository;
	
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Resource
	private Inp1003Repository inp1003Repository;
	
	@Resource
	private Nur0112Repository nur0112Repository;
		
	@Override
	public OCS2005U02ValidationCheckResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U02ValidationCheckRequest request) throws Exception {

		OcsiServiceProto.OCS2005U02ValidationCheckResponse.Builder response = OcsiServiceProto.OCS2005U02ValidationCheckResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String fkinp1001 = "0";
		List<OcsiModelProto.OCS2005U02grdOCS2005Info> list = request.getInfoGrdList();
		
		List<DataStringListItemInfo> result;
		result = inp1001Repository.getPkInp1001Ocs2005U02(hospCode, request.getBunho(), request.getMpressedJaewonYn());
		if(CollectionUtils.isEmpty(result)){
			result = inp1003Repository.OCS2005U02getReserFkInp1001(hospCode, request.getBunho(), "0");
		}
		
		fkinp1001 = CollectionUtils.isEmpty(result) ? "0" : result.get(0).getItem();
		
		if(!CollectionUtils.isEmpty(list)){
			for(OcsiModelProto.OCS2005U02grdOCS2005Info item : list){
				if(DataRowState.MODIFIED.getValue().equals(item.getDataRowState()) || DataRowState.ADDED.getValue().equals(item.getDataRowState())){
					
					OCS2005U02ValidationCheckInfo itemReturn = new OCS2005U02ValidationCheckInfo("", "", "", "true");
					if(fkinp1001.equals("0")){
						itemReturn.setMsgGetpkinp1001("0");							
					}
					
					String siksaCode = nur0112Repository.fnIsSikaCode(hospCode, item.getDirectCont1(), item.getDirectCont1D(), item.getDirectCont2(),
							item.getDirectCont2D(), item.getDirectCont3(), item.getDirectCont3D());
					if(siksaCode.equals("0")){
						itemReturn.setMsg("1");
						itemReturn.setBresult("false");
					}
					
					if(item.getDrtFromDate() == ""){
						itemReturn.setMsg("2");
						itemReturn.setBresult("false");
					}
					
					if(item.getDrtFromDate()!= "" && item.getDrtToDate() != ""){
						if((DateUtil.toDate(item.getDrtFromDate(), DateUtil.PATTERN_YYMMDD)).before( DateUtil.toDate(item.getDrtFromDate(), DateUtil.PATTERN_YYMMDD))){
							itemReturn.setMsg("3");
							itemReturn.setBresult("false");
						}
					}
					
					if(item.getDirectCodeD().trim() == null){
						itemReturn.setMsg("4");
						itemReturn.setBresult("false");
					}
					
					if(item.getDirectCont1D().trim() == null || request.getCboSikjong() == null || request.getCboSikjong() == ""){
						itemReturn.setMsg("5");
						itemReturn.setBresult("false");
					}
					
					if(item.getDirectCont2D().trim() == null || request.getCboJusik() == null || request.getCboJusik() == ""){
						itemReturn.setMsg("6");
						itemReturn.setBresult("false");
					}
					
					if(item.getDirectCont3D().trim() == null || request.getCboBusik() == null || request.getCboBusik() == ""){
						itemReturn.setMsg("7");
						itemReturn.setBresult("false");
					}
					
					if(!StringUtils.isEmpty(item.getDrtFromDate())){
						if(fkinp1001.equals("0")){
							itemReturn.setMsgGetpkinp1001("0");
							itemReturn.setBresult("false");
						}else{
							String strCheck = ocs2005Repository.getOCS2005U02IsNutCheckFromToDate(hospCode
									, DateUtil.toDate(item.getDrtFromDate(), DateUtil.PATTERN_YYMMDD)
									, request.getBunho()
									, item.getBldGubun()
									, item.getPkocs2005()
									, fkinp1001);
							
							if(!strCheck.equals("0")){
								itemReturn.setMsgIsnutcheckfromtodateObj(strCheck);
								itemReturn.setBresult("false");
							}
						}
					}
					
					if(!StringUtils.isEmpty(item.getDrtToDate())){
						if(fkinp1001.equals("0")){
							itemReturn.setMsgGetpkinp1001("0");
							itemReturn.setBresult("false");
						}else{
							String obj = ocs2005Repository.getOCS2005U02IsNutCheckFromToDate(hospCode
									, DateUtil.toDate(item.getDrtToDate(), DateUtil.PATTERN_YYMMDD)
									, request.getBunho()
									, item.getBldGubun()
									, item.getPkocs2005()
									, fkinp1001);
							
							if(!obj.equals("0")){
								itemReturn.setMsgIsnutcheckfromtodateObj(obj);
								itemReturn.setBresult("false");
							}
						}
					}
					
					OcsiModelProto.OCS2005U02ValidationCheckInfo.Builder info = OcsiModelProto.OCS2005U02ValidationCheckInfo.newBuilder();
					itemReturn.setBresult("true");
					itemReturn.setMsgIsnutcheckfromtodateObj("0");
					BeanUtils.copyProperties(itemReturn, info, getLanguage(vertx, sessionId));
					response.addItem(info);
				}
			}
		}
		
		return response.build();
	}
}
