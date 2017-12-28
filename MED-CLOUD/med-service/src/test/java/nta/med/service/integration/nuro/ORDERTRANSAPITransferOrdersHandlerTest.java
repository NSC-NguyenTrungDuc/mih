package nta.med.service.integration.nuro;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class ORDERTRANSAPITransferOrdersHandlerTest extends MessageRequestTest{

	@Test
	public void test() throws Exception{
		
//		NuroModelProto.ORDERTRANSAPIHangmogInfo info = NuroModelProto.ORDERTRANSAPIHangmogInfo.newBuilder()
//				.setHangmogCode("X00007")
//				.setHangmogName("")
//				.setPkocs1003("11338")
//				.build();
//		
//		NuroServiceProto.ORDERTRANSAPITransferOrdersRequest request = NuroServiceProto.ORDERTRANSAPITransferOrdersRequest
//				.newBuilder()
//				.setBunho("000006518")
//				.setPkout1001("4064")
//				.setPerformDate("2016/08/17")
//				.setAction(NuroModelProto.TransferType.SEND_ORDER_DISEASE)
//				.addHangmogItem(info)
//				.build();
		
		NuroModelProto.ORDERTRANSAPIHangmogInfo info = NuroModelProto.ORDERTRANSAPIHangmogInfo.newBuilder()
				.setHangmogCode("X00007")
				.setHangmogName("")
				.setPkocs1003("11340")
				.build();
		
		NuroServiceProto.ORDERTRANSAPITransferOrdersRequest request = NuroServiceProto.ORDERTRANSAPITransferOrdersRequest
				.newBuilder()
				.setBunho("000006522")
				.setPkout1001("4078")
				.setPerformDate("2016/08/18")
				.setAction(NuroModelProto.TransferType.RETRANSFER_ORDER)
				.addHangmogItem(info)
				.build();
		
		sentRequestToMedApp(request, NuroServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
