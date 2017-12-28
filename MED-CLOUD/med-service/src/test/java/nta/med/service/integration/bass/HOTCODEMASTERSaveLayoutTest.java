package nta.med.service.integration.bass;

import java.util.ArrayList;
import java.util.List;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class HOTCODEMASTERSaveLayoutTest extends MessageRequestTest {
	@Test
	public void testHOTCODEMASTERSaveLayoutTest() throws InterruptedException {
		
		 BassModelProto.HOTCODEMASTERGetGrdListInfo.Builder dt = BassModelProto.HOTCODEMASTERGetGrdListInfo.newBuilder();
	        dt.setHotCode("1003062010102");
	        dt.setHotCode7("1003062");
	        dt.setCinCode("01");
	        dt.setDispenseCode("01");
	        dt.setLogisticCode("02");
	        dt.setJanCode("4987128114603");
	        dt.setYakKijunCode("1115400X1019");
	        dt.setYjCode("1115400X1027");
	        dt.setSgCode("641110021");
	        dt.setSgCode1("641110009");
	        dt.setHangmogName("");
	        dt.setHangmogName1("");
	        dt.setHangmogName2("");
	        dt.setStandardUnit("");
	        dt.setPkgNumUnit("1");
	        dt.setOrdDanui("");
	        dt.setPkgTotal("10");
	        dt.setPkgTotalUnit("");
	        dt.setClsif("内");
	        dt.setClassifUpd("1");
	        dt.setManufComp("");
	        dt.setSalesComp("");
	        dt.setSgYmd("20100331");
	        
	        List<BassModelProto.HOTCODEMASTERGetGrdListInfo> dts = new ArrayList<BassModelProto.HOTCODEMASTERGetGrdListInfo>();
	        	dts.add(dt.build());
	        
	        
		BassServiceProto.HOTCODEMASTERSaveLayoutRequest request = BassServiceProto.HOTCODEMASTERSaveLayoutRequest
				.newBuilder()
				.setUserId("K01ADM")
				.addAllLayoutItem(dts)
				.build();
		sentRequestToMedApp(request, BassServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));

	}
}
