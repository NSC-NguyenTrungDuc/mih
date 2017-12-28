package nta.med.service.ihis.handler.ocsa;

import java.text.ParseException;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.ocsa.Ocs3003Q10GrdOrderListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS3003Q10GrdOrderRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS3003Q10GrdOrderResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS3003Q10GrdOrderHandler
extends ScreenHandler<OcsaServiceProto.OCS3003Q10GrdOrderRequest, OcsaServiceProto.OCS3003Q10GrdOrderResponse> {                     
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;        
	                                                                                                                
	@Override         
	@Transactional(readOnly = true)
	public OCS3003Q10GrdOrderResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OCS3003Q10GrdOrderRequest request)
			throws Exception {                                                                   
  	   	OcsaServiceProto.OCS3003Q10GrdOrderResponse.Builder response = OcsaServiceProto.OCS3003Q10GrdOrderResponse.newBuilder();
  	    String hospCode = getHospitalCode(vertx, sessionId);
	   	String language = getLanguage(vertx, sessionId);
		List<Ocs3003Q10GrdOrderListItemInfo> list = new ArrayList<Ocs3003Q10GrdOrderListItemInfo>();
		if(request.getIoGubun().equalsIgnoreCase("O")){
			 list = ocs0132Repository.getOcs3003Q10GrdOrderListItem(hospCode, language,
						DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD), request.getIoGubun(), request.getOrderGubun(), request.getBunho(),
						CommonUtils.parseDouble(request.getPkOcskey()), request.getJubsuNo(), request.getGwa(), request.getDoctor());
		}else if(request.getIoGubun().equalsIgnoreCase("I")){
			 list = ocs0132Repository.getOcs3003Q10GrdOrderListItemUnion(hospCode, language,
						DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD), request.getIoGubun(), request.getOrderGubun(), request.getBunho(),
						CommonUtils.parseDouble(request.getPkOcskey()), request.getJubsuNo(), request.getGwa(), request.getDoctor());
		}
		
		if(!CollectionUtils.isEmpty(list)){
			for(Ocs3003Q10GrdOrderListItemInfo item : list){
				OcsaModelProto.OCS3003Q10GrdOrderListItemInfo.Builder info = OcsaModelProto.OCS3003Q10GrdOrderListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				String buyoCheck = "N";
				buyoCheck = fnOcsBulyongCheckOut(item, buyoCheck);
				info.setBulyongCheck(buyoCheck);
				response.addListResult(info);
			}
		}
		return response.build();
	}     
	private String fnOcsBulyongCheckOut(Ocs3003Q10GrdOrderListItemInfo item,
			String buyoCheck) throws ParseException {
		Date date = DateUtil.toDate(item.getBulyongCheck(), DateUtil.PATTERN_YYMMDD);
		if(StringUtils.isEmpty(item.getBulyongCheck()) ||( date.equals(new Date()) || date.after(new Date()))){
			buyoCheck = "N";
		}else{
			buyoCheck = "Y";
		}
		return buyoCheck;
	}
}