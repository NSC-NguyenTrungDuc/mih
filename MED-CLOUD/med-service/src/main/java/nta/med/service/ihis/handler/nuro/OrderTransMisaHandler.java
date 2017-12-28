package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.out.Out0101;
import nta.med.core.domain.out.Out1001;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.cht.Cht0110Repository;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.dao.medi.out.Out0102Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.OrderTransMisaRequest;
import nta.med.service.ihis.proto.NuroServiceProto.OrderTransMisaResponse;

@Service                                                                                                          
@Scope("prototype")   
@Transactional
public class OrderTransMisaHandler extends ScreenHandler<NuroServiceProto.OrderTransMisaRequest, NuroServiceProto.OrderTransMisaResponse>{

	private static final Log LOGGER = LogFactory.getLog(OrderTransMisaHandler.class); 
	
	@Resource
	Out0101Repository out0101Repository;
	
	@Resource
	Bas0001Repository bas0001Repository;
	
	@Resource
	Out0102Repository out0102Repository;
	
	@Resource
	Out1001Repository out1001Repository;
	
	@Resource
	Ocs0103Repository ocs0103Repository;
	
	@Resource
	Cht0110Repository cht0110Repository;
	
	@Resource
	private CommonRepository commonRepository;
	
	@Override
	public OrderTransMisaResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OrderTransMisaRequest request) throws Exception {
		
		LOGGER.info("In handler: OrderTransMisaHandler");
		
		NuroServiceProto.OrderTransMisaResponse.Builder response = NuroServiceProto.OrderTransMisaResponse.newBuilder();
		
		String hospCode = request.getHopsCode();
		String bunho = request.getBunho();
		String pkout1001 = request.getPkout1001();
		if(!StringUtils.isEmpty(pkout1001)){
			pkout1001 = pkout1001.replace(",", ".");
		}
		
		String hospCodeExt = "";
		String suname = "";
		String zipCode1 = "";
		String zipCode2 = "";
		String address1 = "";
		String pkout1001Ext = "";
		String johap = "";
		String refno = "";
		String receptRefId = "";
		
		// get data from OUT0101
		List<Out0101> lstOut0101 = out0101Repository.getByBunho(hospCode, bunho);
		if(!CollectionUtils.isEmpty(lstOut0101)){
			suname = lstOut0101.get(0).getSuname() == null ? "" : lstOut0101.get(0).getSuname();
			zipCode1 = lstOut0101.get(0).getZipCode1() == null ? "" : lstOut0101.get(0).getZipCode1();
			zipCode2 = lstOut0101.get(0).getZipCode2() == null ? "" : lstOut0101.get(0).getZipCode2();
			address1 = lstOut0101.get(0).getAddress1() == null ? "" : lstOut0101.get(0).getAddress1();
		}
		
		// get JOHAP
		johap = out0102Repository.getJohapByHospCodeAndBunho(hospCode, bunho);
		johap = johap == null ? "" : johap;
		
		// get REFNO if JOHAP is null
		if(StringUtils.isEmpty(johap)){
			refno = commonRepository.getNextVal("MISA_DH_SEQ");
		}
		
		// get PKOUT1001_EXT
		if(!StringUtils.isEmpty(pkout1001)){
			List<Out1001> receptionList = out1001Repository.findPkOut1001Ext(hospCode, bunho, CommonUtils.parseDouble(pkout1001));
			if(!CollectionUtils.isEmpty(receptionList)){
				pkout1001Ext = receptionList.get(0).getPkout1001Ext() == null ? "" : receptionList.get(0).getPkout1001Ext();
				receptRefId = receptionList.get(0).getReceptRefId() == null ? "" : receptionList.get(0).getReceptRefId(); 
			}
		}
		
		response.setSuname(suname);
		response.setZipCode1(zipCode1);
		response.setZipCode2(zipCode2);
		response.setAddress1(address1);
		response.setHopsCodeExt(hospCodeExt);
		response.setJohap(johap);
		response.setPkout1001Ext(pkout1001Ext);
		response.setRefno(refno);
		response.setReceptRefId(receptRefId);
		
		return response.build();
	}

	
}
